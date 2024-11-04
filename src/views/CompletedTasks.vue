<!-- src/views/CompletedTasks.vue -->
<template>
    <div class="completed-tasks">
      <Header title="Completed Tasks" :showBackButton="true" />
      <div class="conteudo">
        <ul v-if="completedTasks.length > 0">
          <li v-for="task in completedTasks" :key="task.id" class="task-item">
            <h2>{{ task.titulo }}</h2>
            <p>{{ task.descricao }}</p>
          </li>
        </ul>
        <p v-else>No completed tasks available.</p>
      </div>
    </div>
  </template>
  
  <script>
  import Header from '@/components/Header.vue'
  import api from '../api/api'
  
  export default {
    components: {
      Header
    },
    data() {
      return {
        completedTasks: [] // Array para armazenar as tarefas concluídas
      };
    },
    async created() {
      try {
        // Obtém as tarefas concluídas da API
        const response = await api.get('/tarefa/completed');
        this.completedTasks = response.data; // Armazena as tarefas concluídas no array
        console.log("Resposta da API:", response.data);
        console.log("Tipo de dado:", typeof response.data);
        console.log("Estrutura dos dados:", JSON.stringify(response.data, null, 2));


      } catch (error) {
        console.error('Erro ao carregar tarefas concluídas:', error);
      }
    }
  };
  </script>
  
  <style scoped>
  .completed-tasks {
    overflow-x: hidden;
  }
  
  .conteudo {
    padding: 20px;
    display: flex;
    justify-content: center;
    flex-direction: column;
    align-items: center;
  }
  
  .task-item {
    background-color: #f9f9f9;
    border-radius: 8px;
    padding: 20px;
    margin: 10px 0;
    width: 100%;
    max-width: 400px;
    box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
  }
  
  h2 {
    color: #333;
    font-size: 18px;
    margin-bottom: 5px;
  }

  ul {
    border: 1px solid red; /* Para visualizar a lista */
    
  }
  
  p {
    color: #666;
    font-size: 14px;
  }
  </style>
  