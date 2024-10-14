import React from 'react';
import App from './App';
import { ToastContainer } from 'react-toastify';
import { createRoot } from 'react-dom/client';
import 'react-toastify/dist/ReactToastify.css';
import './index.css';

const container = document.getElementById('root');
const root = createRoot(container);

root.render(
  <React.StrictMode>
    <App />
    <ToastContainer />
  </React.StrictMode>
);