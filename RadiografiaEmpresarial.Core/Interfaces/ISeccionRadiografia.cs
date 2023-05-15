using RadiografiaEmpresarial.Core.Entities;
using RadiografiaEmpresarial.Core.Entities.EntitiesJoin;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface ISeccionRadiografia
    {
        IEnumerable<RadRespuestas11> seccion1_1(string query);
        IEnumerable<string> seccion1_1Llenados(string query);

        IEnumerable<object> radiografia_estado_organizacion(string query);

        //pruebas
        IEnumerable<RadRespuestas2E> insertarPrueba(string query);

    }
}
