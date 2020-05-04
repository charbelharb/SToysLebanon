using Data;

namespace Core.Logic
{
    public abstract class LogicBase
    {
        protected readonly Context _context;

        protected LogicBase(Context context)
        {
            _context = context;
        }
    }
}
