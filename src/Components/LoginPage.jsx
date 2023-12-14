import { useFormik } from 'formik';
import React, { useRef, useState } from 'react';
import { fetchWithoutToken } from '../helpers/Fetch';
import { Navigate } from 'react-router-dom';

export const LoginPage = () => {
  const [resplogin, setresplogin] = useState('');
  const [validete, setValidate] = useState(false);
  const formik = useFormik({
    initialValues: {
      usuario: '',
      password: '',
    },
    onSubmit: (values, { resetForm }) => {
      onHandleFrom(values);
      resetForm();
    },
  });

  const onHandleFrom = async ({ usuario, password }) => {
    const resp = await fetchWithoutToken(
      'controller',
      { usuario, password },
      'POST'
    );
    const data = await resp.json();
    if (!data.status) {
      setresplogin(() => data.message);
      setValidate(() => false);
    } else {
      setresplogin(() => '');
      setValidate(() => true);
    }
  };

  return (
    <div
      className="container border rounded"
      style={{ width: '50%', marginTop: '5rem' }}
    >
      <div>
        <h2>Login</h2>
      </div>
      <div>
        <form onSubmit={formik.handleSubmit}>
          <input
            type="text"
            name="usuario"
            placeholder="ingrese el usuario"
            className="form-control my-2"
            value={formik.values.usuario}
            onChange={formik.handleChange}
          />
          <input
            type="text"
            name="password"
            placeholder="ingrese el password"
            className="form-control my-2"
            value={formik.values.password}
            onChange={formik.handleChange}
          />

          <button type="submit" className="btn btn-primary">
            Iniciar Session
          </button>
        </form>
        {validete == false ? (
          <p style={{ color: 'red' }}>{resplogin}</p>
        ) : (
          <Navigate to="/create" />
        )}
      </div>
    </div>
  );
};
