namespace UI.Tools.Navigation
{
    internal enum ViewType
    {
        Login,
        SignUp,
        Main
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
