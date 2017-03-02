using DotNetCoreBookstore.ProjectDependencies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;

namespace DotNetCoreBookstore.Dependencies
{
	public class JsonStringFormatter : IStringFormatter
	{
		private readonly IGreeter _greeter;
		private readonly IConfiguration _configuration;
		private readonly ProductMeasures _productMeasures;
		private readonly FavOptions _favOptions;

		public JsonStringFormatter(IGreeter greeter, IConfiguration configuration, ProductMeasures productMeasures
			, IOptions<FavOptions> favourites)
		{
			if (greeter == null) throw new ArgumentNullException("Greeter");
			if (configuration == null) throw new ArgumentNullException("Configuration");
			if (productMeasures == null) throw new ArgumentNullException("Measures");
			if (favourites == null || favourites.Value == null) throw new ArgumentNullException("Favourites");
			_greeter = greeter;
			_configuration = configuration;
			_productMeasures = productMeasures;
			_favOptions = favourites.Value;
		}

		public string FormatMe(object input)
		{
			return JsonConvert.SerializeObject(new { Greeting = _greeter.SendGreeting(), Content = input,
				Mood = _configuration["Mood"], Measures = _productMeasures, Favourites = _favOptions });
		}
	}
}
