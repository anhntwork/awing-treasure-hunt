using Application.Validation.Attributes;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.TreasureHunt
{
    public class CalculateFuelCommand : IRequest<double>
    {
        [Range(1, int.MaxValue)]
        public int N { get; set; }
        [Range(1, int.MaxValue)]
        public int M { get; set; }
        [Range(1, int.MaxValue)]
        public int P { get; set; }
        [PositiveValuesArrayAttribute]
        public int[][] Matrix { get; set; }
    }
}
