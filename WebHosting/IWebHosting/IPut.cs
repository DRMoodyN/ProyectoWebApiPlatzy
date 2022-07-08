using System;
using Microsoft.AspNetCore.Mvc;

namespace WebHosting.IWebHosting
{
    public interface IPut<T>
    {
        public Task<IActionResult> Put(Guid id, T model);
    }
}
