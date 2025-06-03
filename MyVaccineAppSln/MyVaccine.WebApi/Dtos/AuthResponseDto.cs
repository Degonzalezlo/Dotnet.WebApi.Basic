namespace MyVaccine.WebApi.Dtos;

public class AuthResponseDto 
{
    public string Token { get; set; }
    public DateTime Expiration{ get; set; }
    public bool IsSucess { get; set; }
    public string[] Errors { get; set; }

}
