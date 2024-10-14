import React from 'react';
import Rectangle from './components/Rectangle';
import PerimeterDisplay from './components/PerimeterDisplay';
import useDimensions from './hooks/useDimensions';
import './App.css';

const App = () => {
  const { dimensions, handleResize } = useDimensions();

  return (
    <div className="app">
      <Rectangle dimensions={dimensions} onResize={handleResize} />
      <PerimeterDisplay dimensions={dimensions} />
    </div>
  );
};

export default App;