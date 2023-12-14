import { useFormik } from 'formik';
import React, { useEffect, useState } from 'react';
import { fetchWithoutToken } from '../helpers/Fetch';
import Swal from 'sweetalert2';
import { Navigate } from 'react-router-dom';

export const FormPage = () => {
  const [vector, setvector] = useState([{ descripcion: '', id: -1 }]);
  const [login, setlogin] = useState(false);
  useEffect(() => {
    let resp = async () => {
      const resp = await fetchWithoutToken('controller', {}, 'GET');
      const { data } = await resp.json();
      setvector(data);
    };
    resp();
  }, []);

  const formik = useFormik({
    initialValues: {
      nombre: '',
      apellidos: '',
      numeroIdentificacion: 0,
      email: '',
      tipoIdentificacion: 0,
      usuario: '',
      password: '',
    },
    onSubmit: (values, { resetForm }) => {
      onHandleForm(values);
      resetForm();
    },
  });

  const onHandleForm = async ({
    nombre,
    apellidos,
    numeroIdentificacion,
    email,
    tipoIdentificacion,
    usuario,
    password,
  }) => {
    const resp = await fetchWithoutToken(
      'controller/create',
      {
        nombre,
        apellidos,
        numeroIdentificacion,
        email,
        tipoIdentificacion,
        usuario,
        password,
      },
      'POST'
    );
    const { status, message } = await resp.json();
    if (status) {
      Swal.fire('Usuario Creado con exito!');
    } else {
      Swal.fire(`Error! ${message}`);
    }
  };

  return (
    <div className="container">
      <h2 className="my-2">Formulario</h2>
      <form onSubmit={formik.handleSubmit}>
        <input
          className="form-control my-2"
          type="text"
          name="nombre"
          placeholder="Ingrese el nombre"
          value={formik.values.nombre}
          onChange={formik.handleChange}
        />
        <input
          className="form-control my-2"
          type="text"
          name="apellidos"
          placeholder="Ingrese los apellidos"
          value={formik.values.apellidos}
          onChange={formik.handleChange}
        />
        <input
          className="form-control my-2"
          type="number"
          name="numeroIdentificacion"
          placeholder="Ingrese el numero de identificación"
          value={formik.values.numeroIdentificacion}
          onChange={formik.handleChange}
        />
        <input
          className="form-control my-2"
          type="email"
          name="email"
          placeholder="Ingrese el email"
          value={formik.values.email}
          onChange={formik.handleChange}
        />
        <select
          name="tipoIdentificacion"
          className="form-select my-2"
          value={formik.values.tipoIdentificacion}
          onChange={formik.handleChange}
        >
          {vector.map(({ descripcion, id }) => (
            <option value={id} key={id}>
              {descripcion}
            </option>
          ))}
        </select>

        <input
          className="form-control my-2"
          type="text"
          name="usuario"
          placeholder="Ingrese el usuario"
          value={formik.values.usuario}
          onChange={formik.handleChange}
        />
        <input
          className="form-control my-2"
          type="text"
          name="password"
          placeholder="Ingrese el password"
          value={formik.values.password}
          onChange={formik.handleChange}
        />

        <button type="submit" className="btn btn-warning mx-2 my-3">
          Guardar
        </button>
      </form>
      <button onClick={() => setlogin(() => true)} className="btn btn-primary">
        Salir al login
      </button>
      {login && <Navigate to="/" />}
    </div>
  );
};
