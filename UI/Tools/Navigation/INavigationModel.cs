namespace UI.Tools.Navigation
{
    internal enum ViewType
    {
        Login,
        Registration,
        Dashboard,
        Information
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
