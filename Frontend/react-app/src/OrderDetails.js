import React from 'react';
import { FaArrowLeft } from 'react-icons/fa6';
import { format } from 'date-fns';
import { ru } from 'date-fns/locale';

function OrderDetails({ order, onBack }) {
  return (
    <div className="order-details">
      <button onClick={onBack} className="back-btn">
        <FaArrowLeft /> Назад к списку
      </button>
      <h2>Детали заказа {order.number}</h2>
      
      <div className="details-section">
        <h3>Информация об отправителе</h3>
        <p><strong>Город:</strong> {order.locationSender.city}</p>
        <p><strong>Адрес:</strong> {order.locationSender.address}</p>
      </div>
      
      <div className="details-section">
        <h3>Информация о получателе</h3>
        <p><strong>Город:</strong> {order.locationReceiver.city}</p>
        <p><strong>Адрес:</strong> {order.locationReceiver.address}</p>
      </div>
      
      <div className="details-section">
        <h3>Информация о грузе</h3>
        <p><strong>Вес груза:</strong> {order.cargoWeightInKg} кг</p>
        <p><strong>Дата забора груза:</strong> {format(new Date(order.cargoPickupDate), 'dd.MM.yy', { locale: ru })}</p>
      </div>
    </div>
  );
}

export default OrderDetails;