using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherRest.ViewModels;

using Xamarin.Forms;

namespace WeatherRest.Views
{
	public partial class MainCarouselPage : CarouselPage
	{
		public MainCarouselPage ()
		{
			InitializeComponent ();
            var vm = new WeatherContentViewModel();
            BindingContext = vm;
        }
	}
}
