namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenDefaults
    {

        public const string ValidAudiance = "https://localhost";  //Token Kim Tarafından Dinlenecek
        public const string ValidIssuer = "https://localhost";  //Token Kim Tarafından Yayınlacanak
        public const string Key = "pGodC50s2IKHN1oTqfsE5AP1Eclq9seQJwlYtRTaK6s00GlKn15mklSsJ6KF4bBQTlM5pTBPRddiR7frOgEOyjs9x4JTJuSek1XUvFP880YvoSFxeS8DVhazk5VJGVNmr5cMAZjxUjmpMFVHllOwsgzF6dGNGIBgtWT2XugCglUVJ5J3ZqQklOrvCytmXgbSlldQSZxOnvc1XR9SImNsu2a0iiXAaw6UPOipz1CFvGvGbnfLyeXtzvT0B98nEfRi";
        public const int Expire = 10;
    }
}
