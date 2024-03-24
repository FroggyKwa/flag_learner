using FlagLearner.ViewModels;
using System.ComponentModel;

namespace FlagLearner.Views
{
    public partial class CountryInfoForm : Form
    {
        CountryInfoViewModel DataContext = null!;
        public CountryInfoForm(CountryInfoViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }

        private void CountryInfoForm_Load(object sender, EventArgs e)
        {
            Text = DataContext.selectedCountry.ToString();
            flagPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            flagPictureBox.ImageLocation = DataContext.selectedCountry.ImageUrl;
            TypeDescriptor.AddAttributes(
                DataContext.countryInfo,
                new Attribute[] { new ReadOnlyAttribute(true) });
            CountryInfoPropertyGridView.SelectedObject = DataContext.countryInfo;
        }
    }
}
