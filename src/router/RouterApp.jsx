import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { LoginPage } from '../Components/LoginPage';
import { FormPage } from '../Components/FormPage';

export const RouterApp = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<LoginPage />} />
        <Route path="/create" element={<FormPage />} />
      </Routes>
    </BrowserRouter>
  );
};
