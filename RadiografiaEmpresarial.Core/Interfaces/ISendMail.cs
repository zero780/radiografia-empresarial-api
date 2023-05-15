using RadiografiaEmpresarial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiografiaEmpresarial.Core.Interfaces
{
    public interface ISendMail
    {
        bool Send(string subject, string body, string correo);
        bool WelcomeMail(AuthUsuarios user);
        bool WelcomeToGroupMail(AuthUsuarios user); 
        bool ResponseRadMail(AuthUsuarios user, CoreGrupos grupos);
    }
}
