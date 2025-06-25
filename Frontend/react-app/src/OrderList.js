import React from 'react';
import { format } from 'date-fns';
import { ru } from 'date-fns/locale';

function OrderList({ orders, onOrderClick, loading }) {
  if (loading) return <div>Загрузка списка заказов...</div>;
  
  return (
    <div className="order-list">
      <h2>Список заказов</h2>
      {orders.length === 0 ? (
        <p>Нет созданных заказов</p>
      ) : (
        <ul>
          {orders.map((order) => (
            <li key={order.id} onClick={() => onOrderClick(order.id)} className="order-item">
              <div className="order-item-header">
                <span className="order-number">{order.number}</span>
                <span className="order-date">{format(new Date(order.cargoPickupDate), 'dd.MM.yy', { locale: ru })}</span>
              </div>
              <div className="order-route">
                {order.locationSender.city} → {order.locationReceiver.city}
              </div>
              <div className="order-weight">Вес: {order.cargoWeightInKg} кг</div>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default OrderList;