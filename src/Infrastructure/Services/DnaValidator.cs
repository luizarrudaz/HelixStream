using System.Buffers;
using System.Text;
using System.Threading.Channels;
using Domain.Interfaces;

namespace Infrastructure.Services;

public class DnaValidator : IDnaValidator
{
    private static readonly SearchValues<char> ValidDnaChars = 
        SearchValues.Create("ATCGNatcgn\n\r");


    public bool ValidateChunk(byte[] buffer, int length)
    {
        ReadOnlySpan<char> chunk = Encoding.ASCII.GetChars(buffer, 0, length);
        
        int invalidIndex = chunk.IndexOfAnyExcept(ValidDnaChars);

        return invalidIndex == -1;
    }
}