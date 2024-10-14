import React from 'react';
import '../styles/PerimeterDisplay.css';

const PerimeterDisplay = ({ dimensions }) => {
  const perimeter = 2 * (dimensions.width + dimensions.height);
  return (
    <div className="perimeter-container">
      <span className="perimeter-label">Perimeter:</span>
      <span className="perimeter-value">{perimeter}</span>
    </div>
  );
};

export default PerimeterDisplay;