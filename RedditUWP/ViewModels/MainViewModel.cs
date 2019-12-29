using RedditUWP.ViewModels.Base;

namespace RedditUWP.ViewModels
{
    class MainViewModel : BindableBase
    {
        #region Attributes
        private int id;
        #endregion
        #region Constructors
        public MainViewModel()
        {
            this.Id = 10;
        }
        #endregion
        #region Properties
        public int Id 
        {
            get
            {
                return id;
            }
            set
            {
                this.SetProperty(ref this.id, value);
            }
        }
        #endregion
    }
}
