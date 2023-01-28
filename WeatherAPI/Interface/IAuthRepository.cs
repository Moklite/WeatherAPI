using WeatherAPI.DTO;

namespace WeatherAPI.Interface
{
   
        public interface IAuthRepository
        {
            public Task<object> Login(LoginDTO model);
            public Task<object> Register(RegisterDTO user);
        }
    
}
