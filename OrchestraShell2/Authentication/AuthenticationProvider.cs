using Catel.MVVM;
using System.Windows;

namespace OrchestraShell2.Authentication
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        /// <summary>
        /// Gets or sets the role the user is currently in.
        /// </summary>
        /// <value>The role.</value>
        public string Role { get; set; }

        public bool CanCommandBeExecuted(ICatelCommand command, object commandParameter)
        {
            //podemos identificar el comando con la propiedad tag de ICatelCommand

            return true;
        }

        public bool HasAccessToUIElement(FrameworkElement element, object tag, object authenticationTag)
        {
            var authenticationTagAsString = authenticationTag as string;
            if (authenticationTagAsString != null)
            {
                if (string.Compare(authenticationTagAsString, Role, true) == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
