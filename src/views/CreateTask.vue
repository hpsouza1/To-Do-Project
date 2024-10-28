<template>
    <div class="create-task">
      <h2>Criar Nova Tarefa</h2>
      <form @submit.prevent="addTask">
        <input type="text" v-model="title" placeholder="Título" required />
        <textarea v-model="description" placeholder="Descrição" required></textarea>
        <button type="submit">Adicionar</button>
      </form>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        title: '',
        description: ''
      };
    },
    methods: {
      addTask() {
        const newTask = { title: this.title, description: this.description };
        // Aqui, envie `newTask` para o backend usando Axios
        console.log('Nova Tarefa:', newTask);
        this.$router.push('/'); // Redireciona para a home
      }
    }
  };
  </script>
  
  <style scoped>
  .create-task {
    padding: 20px;
  }
  input, textarea {
    display: block;
    margin: 10px 0;
    width: 100%;
    padding: 10px;
  }
  button {
    padding: 10px 20px;
    background-color: #9f94d2;
    color: white;
    border: none;
    border-radius: 5px;
  }
  </style>
  