import Vue from 'vue';
import App from './App.vue'; // Ou o componente principal da sua aplicação
import router from './router'; // Certifique-se que o caminho está correto

// Inicializa a instância do Vue
new Vue({
  router, // Adiciona o Vue Router à instância
  render: h => h(App) // Renderiza o componente principal
}).$mount('#app');
