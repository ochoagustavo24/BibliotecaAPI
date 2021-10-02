using BibliotecaAPI.Core;
using BibliotecaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaAPI.DAO
{
    public class CategoriaDAO
    {
        private readonly BibliotecaContext context;
        public CustomError customError;

        public CategoriaDAO(BibliotecaContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasAsync()
        {
            return await context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetCategoriaIdAsync(int id)
        {
            return await context.Categorias.FindAsync(id);
        }

        public async Task<bool> AddCategoryAsync(Categoria categoria)
        {
            Categoria registroDuplicado;

            registroDuplicado = await context.Categorias.FirstOrDefaultAsync(c => c.NombreCategoria == categoria.NombreCategoria);

            // Verifica que el registro no esté duplicado
            if(registroDuplicado != null) 
            {
                customError = new CustomError(400, "Ya existe una categoria con este nombre.", "Nombre");

                return false;
            }

            context.Categorias.Add(categoria);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ModifyCategoryAsync(Categoria categoria)
        {
            Categoria registroDuplicado;

            try
            {
                // Se verifica si existe una categoria con el mismo nombre pero distinto Id.

                registroDuplicado = await context.Categorias.FirstOrDefaultAsync(c => c.NombreCategoria == categoria.NombreCategoria
                                                                                && c.Id != categoria.Id);

                if (registroDuplicado != null)
                {
                    customError = new CustomError(400, "Ya existe una categoria con este nombre, proporcione un nombre diferente", "Nombre");
                    return false;
                }

                context.Entry(categoria).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(categoria.Id))
                {
                    customError = new CustomError(400, "No existe la categoria especificada", "Categoria");
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var categoria = await context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                customError = new CustomError(400, "La categoria que desea borrar no existe.", "Id");

                return false;
            }

            context.Categorias.Remove(categoria);

            await context.SaveChangesAsync();

            return true;
        }

        private bool CategoryExists(int id)
        {
            return context.Categorias.Any(e => e.Id == id);
        }
    }
}
