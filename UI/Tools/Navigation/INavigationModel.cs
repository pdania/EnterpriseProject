namespace UI.Tools.Navigation
{
    internal enum ViewType
    {
        Login,
        Registration,
        Dashboard
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
