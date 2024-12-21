using MediatR;

namespace Domain.Commands.TreasureHunt
{
    public class CalculateFuelCommand : IRequest<double>
    {
        public int N { get; set; }
        public int M { get; set; }
        public int P { get; set; }
        public int[][] Matrix { get; set; }
    }
}
