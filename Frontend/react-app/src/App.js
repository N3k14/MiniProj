import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './App.css';
import OrderForm from './OrderForm';
import OrderList from './OrderList';
import OrderDetails from './OrderDetails';

const API_URL = 'http://localhost:8080/api/orders';

function App() {
  const [orders, setOrders] = useState([]);
  const [view, setView] = useState('form');
  const [selectedOrder, setSelectedOrder] = useState(null);
  const [loading, setLoading] = useState({
    list: false,
    formSubmit: false,
    details: false
  });
  const [error, setError] = useState(null);
  const [successMessage, setSuccessMessage] = useState(null);

  const fetchOrders = async () => {
    setLoading(prev => ({...prev, list: true}));
    setError(null);
    try {
      const response = await axios.get(API_URL);
      setOrders(response.data);
    } catch (err) {
      setError(err.message);
      console.error('Error fetching orders:', err);
    } finally {
      setLoading(prev => ({...prev, list: false}));
    }
  };

  const addOrder = async (newOrder) => {
    setLoading(prev => ({...prev, formSubmit: true}));
    setError(null);
    setSuccessMessage(null);
    
    try {
      const response = await axios.post(API_URL, newOrder);
      
      if (response.status === 201) {
        setSuccessMessage('Заказ успешно создан!');
      } else {
        setError('Сервер не подтвердил создание заказа');
      }
    } catch (err) {
      setError(err.response?.data?.message || 'Ошибка при создании заказа');
      console.error('Error creating order:', err);
    } finally {
      setLoading(prev => ({...prev, formSubmit: false}));
    }
  };

  const clearStatus = () => {
    setError(null);
    setSuccessMessage(null);
  };

  useEffect(() => {
    if (view === 'list') {
      fetchOrders();
    }
  }, [view]);

  const handleOrderClick = async (orderId) => {
    setLoading(prev => ({...prev, details: true}));
    setError(null);
    try {
      const response = await axios.get(`${API_URL}/${orderId}`);
      setSelectedOrder(response.data);
      setView('details');
    } catch (err) {
      setError(err.message);
      console.error('Error fetching order details:', err);
    } finally {
      setLoading(prev => ({...prev, details: false}));
    }
  };

  const navigateTo = (view) => {
    setView(view);
    setError(null);
    setSuccessMessage(null);
  };

  return (
    <div className="app">
      <header className="app-header">
        <h1>Система приемки заказов на доставку</h1>
        <nav>
          <button onClick={() => navigateTo('form')}>Создать заказ</button>
          <button onClick={() => navigateTo('list')}>Список заказов</button>
        </nav>
      </header>

      <main className="app-content">
        {view === 'form' && (
          <OrderForm 
            onSubmit={addOrder} 
            loading={loading.formSubmit}
            successMessage={successMessage}
            error={error}
            onClearStatus={clearStatus}
          />
        )}
        
        {view === 'list' && (
          <OrderList 
            orders={orders} 
            onOrderClick={handleOrderClick} 
            loading={loading.list}
          />
        )}
        
        {view === 'details' && selectedOrder && (
          <OrderDetails 
            order={selectedOrder} 
            onBack={() => navigateTo('list')} 
            loading={loading.details}
          />
        )}
      </main>
    </div>
  );
}

export default App;