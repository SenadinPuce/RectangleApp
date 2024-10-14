import { render, screen } from '@testing-library/react';
import App from './App';

test('renders Rectangle Drawer title', () => {
  render(<App />);
  const titleElement = screen.getByText(/Rectangle Drawer/i);
  expect(titleElement).toBeInTheDocument();
});

test('renders Perimeter label', () => {
  render(<App />);
  const labelElement = screen.getByText(/Perimeter:/i);
  expect(labelElement).toBeInTheDocument();
});