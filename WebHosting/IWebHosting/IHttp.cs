using System;
using Microsoft.AspNetCore.Mvc;

namespace WebHosting.IWebHosting
{
    public interface IHttp<T>
    {
        public Task<IActionResult> Get(Guid id);

        public Task<IActionResult> GetAll();

        public Task<IActionResult> Post(T model);

        public Task<IActionResult> Delete(Guid id);
    }
}
