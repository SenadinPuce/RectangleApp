import React, { useRef } from 'react';
import '../styles/Rectangle.css';

const Rectangle = ({ dimensions, onResize }) => {
  const rectRef = useRef(null);
  const boundaryRef = useRef(null);

  const handleMouseDown = (e) => {
    const startX = e.clientX;
    const startY = e.clientY;
    const startWidth = dimensions.width;
    const startHeight = dimensions.height;

    const handleMouseMove = (e) => {
      const boundaryRect = boundaryRef.current.getBoundingClientRect();
      const maxWidth = boundaryRect.width - 100; // 50px margin on each side
      const maxHeight = boundaryRect.height - 100; // 50px margin on each side
      const newWidth = Math.min(startWidth + (e.clientX - startX), maxWidth);
      const newHeight = Math.min(startHeight + (e.clientY - startY), maxHeight);
      onResize({ width: newWidth, height: newHeight }, false);
    };

    const handleMouseUp = (e) => {
      document.removeEventListener('mousemove', handleMouseMove);
      document.removeEventListener('mouseup', handleMouseUp);
      const boundaryRect = boundaryRef.current.getBoundingClientRect();
      const maxWidth = boundaryRect.width - 100; // 50px margin on each side
      const maxHeight = boundaryRect.height - 100; // 50px margin on each side
      const newWidth = Math.min(startWidth + (e.clientX - startX), maxWidth);
      const newHeight = Math.min(startHeight + (e.clientY - startY), maxHeight);
      onResize({ width: newWidth, height: newHeight }, true);
    };

    document.addEventListener('mousemove', handleMouseMove);
    document.addEventListener('mouseup', handleMouseUp);
  };

  return (
    <div className="rectangle-container">
      <h1>Rectangle Drawer</h1>
      <div ref={boundaryRef} className="boundary">
        <svg width="100%" height="100%" className="svg-canvas">
          <rect
            ref={rectRef}
            x="50"
            y="50"
            width={dimensions.width}
            height={dimensions.height}
            fill="blue"
            stroke="black"
            strokeWidth="2"
            onMouseDown={handleMouseDown}
          />
          <text x={50 + dimensions.width / 2} y="45" fill="black" textAnchor="middle" className="label">Width: {dimensions.width}</text>
          <text x={50 + dimensions.width + 10} y={50 + dimensions.height / 2} fill="black" textAnchor="start" className="label">Height: {dimensions.height}</text>
        </svg>
      </div>
    </div>
  );
};

export default Rectangle;