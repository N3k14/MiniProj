import React, { useState } from 'react';

function OrderForm({ onSubmit, loading, successMessage, error, onClearStatus }) {
  const [formData, setFormData] = useState({
    citySender: '',
    addressSender: '',
    cityReceiver: '',
    addressReceiver: '',
    cargoWeightInKg: '',
    cargoPickupDate: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(formData);
  };

  return (
    <form onSubmit={handleSubmit} className="order-form">
      <h2>Создание нового заказа</h2>
      
      {successMessage && (
        <div className="alert alert-success">
          {successMessage}
          <button 
            type="button" 
            onClick={onClearStatus}
            className="close-message"
          >
            ×
          </button>
        </div>
      )}
      
      {error && (
        <div className="alert alert-error">
          {error}
          <button 
            type="button" 
            onClick={onClearStatus}
            className="close-message"
          >
            ×
          </button>
        </div>
      )}
      
      <div className="form-group">
        <label>
          Город отправителя:
          <input
            type="text"
            name="citySender"
            value={formData.citySender}
            onChange={handleChange}
            maxLength={30}
            required
          />
        </label>
      </div>
      
      <div className="form-group">
        <label>
          Адрес отправителя:
          <input
            type="text"
            name="addressSender"
            value={formData.addressSender}
            onChange={handleChange}
            maxLength={50}
            required
          />
        </label>
      </div>
      
      <div className="form-group">
        <label>
          Город получателя:
          <input
            type="text"
            name="cityReceiver"
            value={formData.cityReceiver}
            onChange={handleChange}
            maxLength={30}
            required
          />
        </label>
      </div>
      
      <div className="form-group">
        <label>
          Адрес получателя:
          <input
            type="text"
            name="addressReceiver"
            value={formData.addressReceiver}
            onChange={handleChange}
            maxLength={50}
            required
          />
        </label>
      </div>
      
      <div className="form-group">
        <label>
          Вес груза (кг):
          <input
            type="number"
            name="cargoWeightInKg"
            value={formData.cargoWeightInKg}
            onChange={handleChange}
            required
            min="0.1"
            max="10000"
            step="0.1"
          />
        </label>
      </div>
      
      <div className="form-group">
        <label>
          Дата забора груза:
          <input
            type="date"
            name="cargoPickupDate"
            value={formData.cargoPickupDate}
            onChange={handleChange}
            required
          />
        </label>
      </div>
      
      <button 
        type="submit" 
        className="submit-btn"
        disabled={loading}
      >
        {loading ? 'Отправка...' : 'Создать заказ'}
      </button>
    </form>
  );
}

export default OrderForm;