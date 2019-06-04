using System.Collections;

namespace UI.Data
{
    public interface IRunLater
    {
        void RunLater(System.Action method, float waitSeconds);

        IEnumerator RunLaterCoroutine(System.Action method, float waitSeconds);        
    }
}
