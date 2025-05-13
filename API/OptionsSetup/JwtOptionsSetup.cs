using Hotel_Restaurant_Reservation.Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace Hotel_Restaurant_Reservation.API.OptionsSetup;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private const string SECTION_NAME = "Jwt";
    private readonly IConfiguration configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        configuration.GetSection(SECTION_NAME).Bind(options);
    }
}
