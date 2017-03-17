using System;

namespace WebFormsProject.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        DX3Context Get();
    }
}
