using RadiografiaEmpresarial.Core.CustomEntities;
using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Exceptions;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Core.QueryFilters;
using RadiografiaEmpresarial.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Services
{
    public class OrganizacionService : IOrganizacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrganizacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteOrganizacion(long id, string nomUser)
        {
            var user = await _unitOfWork.AuthUsuarioRepository.GetUsuariosconPermisosORG(nomUser);
            if(user == null)
            {
                return false;
            }
            var org = await _unitOfWork.OrganizacionesRepository.GetById(id);
            

            org.DeletedAt = DateTime.Now;
            org.DeletedBy = user.Id;
            //org.DeletedBy = idUser;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<CoreOrganizaciones> GetOrganizacion(long id)
        {
            return await _unitOfWork.OrganizacionesRepository.GetById(id);
        }

        public PagedList<CoreOrganizaciones> GetOrganizaciones(OrganizacionQueryFilter filters)
        {
            var org = _unitOfWork.OrganizacionesRepository.GetAll();
            if(filters.Slug != null)
            {
                org = org.Where(x => x.Slug.Contains(filters.Slug));
            }
            if(filters.Identificacion != null)
            {
                org = org.Where(x => x.Identificacion.Contains(filters.Identificacion));
            }
            if(filters.Nombre != null)
            {
                org = org.Where(x => x.Nombre.Contains(filters.Nombre));
            }
            if(filters.Desde != null && filters.Hasta != null)
            {
                org = org.Where(x => x.CreatedAt >= filters.Desde && x.CreatedAt <= filters.Hasta);
            }
            if(filters.CreatedBy != null)
            {
                org = org.Where(x => x.CreatedBy == filters.CreatedBy);
            }

            var pagedOrg = PagedList<CoreOrganizaciones>.Create(org, filters.PageNumber, filters.pageSize);

            if (filters.PageNumber > 0 && filters.pageSize > 0)
            {
                return pagedOrg;
            }
            

            return PagedList<CoreOrganizaciones>.Create(org, 1, pagedOrg.TotalCount);


        }

        public async Task<bool> InsertOrganizacion(CoreOrganizaciones emp, string nomUser)
        {
            var user = await _unitOfWork.AuthUsuarioRepository.GetUsuariosconPermisosORG(nomUser);

            if(user == null)
            {
                return false;
            }

            if (emp.Nombre.Length < 2 || emp.Nombre == null)
            {
                throw new BusinessException("El nombre de la Organización no es valido");
            }
            emp.Nombre = emp.Nombre.ToUpper();
            emp.Slug = SlugUtil.Generate(emp.Nombre);
            if(emp.Slug.Length<2 || emp.Slug == null)
            {
                throw new BusinessException("Slug Incorrecto (Menos de 3 caracteres) o Nulo");
            }

            try
            {
                var identificacion = long.Parse(emp.Identificacion); //Valida que solo sea entero
                if (emp.Identificacion.Length < 13 || emp.Identificacion.Length >13)
                {
                    throw new BusinessException("Identificación Erronea (Debe tener 13 digitos)");
                }
            }
            catch
            {

                throw new BusinessException("Identificación Erronea (Ingresar solo números)");
            }

            IEnumerable<CoreOrganizaciones> organizacion = _unitOfWork.OrganizacionesRepository.GetAll();
            foreach(var org in organizacion)
            {
                if (org.Identificacion.Equals(emp.Identificacion))
                {
                    throw new BusinessException("Identificación ya existe");
                }
                if (org.Slug.ToLower().Equals(emp.Slug.ToLower()))
                {
                    throw new BusinessException("Slug de Organización ya existe");
                }
                if (org.Nombre.ToLower().Equals(emp.Nombre.ToLower()))
                {
                    throw new BusinessException("Nombre de Organización ya existe");
                }
            }
            emp.CreatedBy = user.Id;
            emp.CreatedAt = DateTime.Now;
            emp.UpdatedAt = DateTime.Now;

            try
            {
                await _unitOfWork.OrganizacionesRepository.Add(emp);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            
            
        }

        public async Task<bool> UpdateOrganizacion(CoreOrganizaciones emp, string nomUser)
        {
            var user = await _unitOfWork.AuthUsuarioRepository.GetUsuariosconPermisosORG(nomUser);

            if(user == null)
            {
                return false;
            }

            var currentOrg = await _unitOfWork.OrganizacionesRepository.GetById(emp.Id);

            if (emp.Nombre == null)
            {
                throw new BusinessException("El nombre de la Organización no debe de ser nulo");
            }
            else
            {
                if (emp.Nombre.Length < 2)
                {
                    throw new BusinessException("El nombre de la Organización no es valido");
                }
            }

            if (emp.Slug == null)
            {
                throw new BusinessException("Slug Incorrecto no debe de ser nulo");
            }
            else
            {
                if (emp.Slug.Length < 3)
                {
                    throw new BusinessException("Slug Incorrecto(Menos de 3 caracteres)");
                }
            }

            if (emp.Identificacion == null)
            {
                throw new BusinessException("Identificación no debe ser nula");
            }
            else {
                try
                {
                    var identificacion = long.Parse(emp.Identificacion);

                    if (emp.Identificacion.Length < 13 || emp.Identificacion.Length > 13)
                    {
                        throw new BusinessException("Identificación Erronea(Debe tener 13 digitos)");
                    }
                }
                catch
                {

                    throw new BusinessException("Identificación Erronea(Ingresar solo números)");
                }
            }

            IEnumerable<CoreOrganizaciones> organizacion = _unitOfWork.OrganizacionesRepository.GetAll();
            foreach (var org in organizacion)
            {
                if(org.Id != emp.Id)
                {
                    if (org.Identificacion.Equals(emp.Identificacion))
                    {
                        throw new BusinessException("Ruc ya existe");
                    }
                    if (org.Nombre.ToLower().Equals(emp.Nombre.ToLower()))
                    {
                        throw new BusinessException("Nombre de Organización ya existe");
                    }
                    if (org.Slug.ToLower().Equals(emp.Slug.ToLower()))
                    {
                        throw new BusinessException("Slug ya existe");
                    }
                }    
            }
            currentOrg.Slug = emp.Slug;
            currentOrg.Nombre = emp.Nombre;
            currentOrg.Identificacion = emp.Identificacion;
            currentOrg.UpdatedBy = user.Id; 
            currentOrg.UpdatedAt = DateTime.Now;
            
            _unitOfWork.OrganizacionesRepository.Update(currentOrg);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
