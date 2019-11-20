using System;
using UI.Views;

namespace UI.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {
            
        }
   
        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    ViewsDictionary.Add(viewType,new LoginView());
                    break;
                case ViewType.Registration:
                    ViewsDictionary.Add(viewType, new RegistrationView());
                    break;
                case ViewType.Dashboard:
                    ViewsDictionary.Add(viewType, new DashboardView());
                    break;
                case ViewType.Information:
                    ViewsDictionary.Add(viewType, new InformationView());
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
