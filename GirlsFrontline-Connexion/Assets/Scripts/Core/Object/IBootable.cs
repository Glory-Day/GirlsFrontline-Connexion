using System.Collections;

namespace Core.Object
{
    public interface IBootable
    {
        public IEnumerator Booting();

        public bool IsBooting { get; }
    }
}
