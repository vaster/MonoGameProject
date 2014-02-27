namespace SpaceInvaders
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using MonoGame.Framework;

    /// <summary>
    /// The root page used to display the game.
    /// </summary>
    public sealed partial class GamePage : SwapChainBackgroundPanel
    {
        readonly GameEngine _game;

        public GamePage(string launchArguments)
        {
            this.InitializeComponent();

            // Create the game.
            _game = XamlGame<GameEngine>.Create(launchArguments, Window.Current.CoreWindow, this);
        }
    }
}
