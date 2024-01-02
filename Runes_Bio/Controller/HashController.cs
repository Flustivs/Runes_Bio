using System.Security.Cryptography;
namespace Runes_Bio.Controller
{
	public class HashController
	{
		private const int _keySize = 32;
		private const int _saltSize = 16;
		private const int _iterations = 100000;
		private HashAlgorithmName _algorithmName = HashAlgorithmName.SHA256;
		private const char _segmentDelimeter = ':';
		internal string Hash(string plainText)
		{
			byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);
			byte[] hash = Rfc2898DeriveBytes.Pbkdf2(plainText, salt, _iterations, _algorithmName, _keySize);
			return string.Join(_segmentDelimeter, Convert.ToHexString(hash), Convert.ToHexString(salt), _iterations, _algorithmName);
		}
		internal bool Verify(string input, string hashstring)
		{
			string[] segment = hashstring.Split(_segmentDelimeter);
			byte[] hash = Convert.FromHexString(segment[0]);
			byte[] salt = Convert.FromHexString(segment[1]);
			int iterations = Convert.ToInt32(segment[2]);
			HashAlgorithmName algorithmName = new HashAlgorithmName(segment[3]);
			byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(input, salt, iterations, algorithmName, hash.Length);
			return CryptographicOperations.FixedTimeEquals(inputHash, hash);
		}
	}
}
