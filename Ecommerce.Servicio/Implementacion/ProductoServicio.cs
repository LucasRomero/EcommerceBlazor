﻿using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Modelo;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Servicio.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Servicio.Implementacion;
public class ProductoServicio: IProductoServicio
{
    private readonly IGenericoRepositorio<Producto> _modeloRepositorio;
    private readonly IMapper _mapper;

    public ProductoServicio(IGenericoRepositorio<Producto> modeloRepositorio, IMapper mapper)
    {
        _modeloRepositorio = modeloRepositorio;
        _mapper = mapper;
    }


    public async Task<List<ProductoDTO>> Catalogo(string categoria, string buscar)
    {
        try
        {
            var consulta = _modeloRepositorio.Consultar(p => 
            p.Nombre.ToLower().Contains(buscar.ToLower()) &&
            p.IdCategoriaNavigation.Nombre.ToLower().Contains(categoria.ToLower())
            );

            List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());

            return lista;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<ProductoDTO> Crear(ProductoDTO modelo)
    {
        try
        {
            var dbModelo = _mapper.Map<Producto>(modelo);
            var rspModelo = await _modeloRepositorio.Crear(dbModelo);

            if (rspModelo.IdProducto != 0)
                return _mapper.Map<ProductoDTO>(rspModelo);
            else throw new TaskCanceledException("No se pudo crear");
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> Editar(ProductoDTO modelo)
    {
        try
        {
            var consulta = _modeloRepositorio.Consultar(p => p.IdProducto == modelo.IdProducto);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
            {
                fromDbModelo.Nombre = modelo.Nombre;
                fromDbModelo.Descripcion = modelo.Descripcion;
                fromDbModelo.IdCategoria = modelo.IdCategoria;
                fromDbModelo.Precio = modelo.Precio;
                fromDbModelo.PrecioOferta = modelo.PrecioOferta;
                fromDbModelo.Cantidad = modelo.Cantidad;
                fromDbModelo.Imagen = modelo.Imagen;

                var respuesta = await _modeloRepositorio.Editar(fromDbModelo);


                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;
            }
            else
            {
                throw new TaskCanceledException("Producto no encontrado");
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> Eliminar(int id)
    {
        try
        {
            var consulta = _modeloRepositorio.Consultar(p => p.IdProducto == id);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
            {
                var respuesta = await _modeloRepositorio.Eliminar(fromDbModelo);
                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar la producto");
                return respuesta;
            }
            else
                throw new TaskCanceledException("producto no encontrado");
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<List<ProductoDTO>> Lista(string buscar)
    {
        try
        {
            var consulta = _modeloRepositorio.Consultar(p =>
            p.Nombre.ToLower().Contains(buscar.ToLower()));

            consulta = consulta.Include(c => c.IdCategoriaNavigation);

            var productos = await consulta.ToListAsync();

            List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(productos);

            return lista;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<ProductoDTO> Obtener(int id)
    {
        try
        {
            var consulta = _modeloRepositorio.Consultar(p => p.IdProducto == id);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
            {
                return _mapper.Map<ProductoDTO>(fromDbModelo);
            }
            else
                throw new TaskCanceledException("Producto no encontrado");

        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
