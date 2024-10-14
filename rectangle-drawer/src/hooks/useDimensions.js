import { useState, useEffect } from 'react';
import { toast } from 'react-toastify';
import { getDimensions, updateDimensions } from '../api/dimensionsApi';

const useDimensions = () => {
  const [dimensions, setDimensions] = useState({ width: 50, height: 100 });

  useEffect(() => {
    const fetchDimensions = async () => {
      try {
        const data = await getDimensions();
        setDimensions(data);
      } catch (error) {
        console.error('Error fetching dimensions:', error);
        toast.error('Failed to fetch dimensions. Please try again later.');
      }
    };

    fetchDimensions();
  }, []);

  const handleResize = async (newDimensions, validate) => {
    setDimensions(newDimensions);
    if (validate) {
      try {
        const response = await updateDimensions(newDimensions);
        if (response.error) {
          toast.error(response.error);
        }
      } catch (error) {
        console.error('Error updating dimensions:', error);
        toast.error('Failed to update dimensions. Ensure width is smaller than height.');
      }
    }
  };

  return { dimensions, handleResize };
};

export default useDimensions;