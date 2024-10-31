<!-- src/views/CreateTask.vue -->
<template>
  <div class="create-task">
    <Header title="Add Task" :showBackButton="true" />
    <div class="conteudo">
      <form @submit.prevent="addTask">
        <input type="text" id="titulo" v-model="titulo" placeholder="Title" required />
    
        <input id="descricao" v-model="descricao" placeholder="Detail" required/>
        
        <button type="submit">ADD</button>
      </form>
    </div>
  </div>
</template>

<script>
import Header from '@/components/Header.vue'
import api from '../api/api' // Certifique-se de que o caminho está correto

export default {
  components: {
    Header
  },
  data() {
    return {
      titulo: '',
      descricao: ''
    };
  },
  methods: {
    async addTask() {
      const newTask = { titulo: this.titulo, descricao: this.descricao }; // Altere as chaves se o backend esperar outro nome
      try {
        // Envia a nova tarefa para o backend
        const response = await api.post('/tarefa', newTask);
        console.log('Tarefa criada:', response.data); // Log para conferir o retorno da API

        // Redireciona para a página inicial após criar a tarefa
        this.$router.push('/');
      } catch (error) {
        console.error('Erro ao criar tarefa:', error); // Log de erro
        
      }
    }
  }
};
</script>

<style scoped>
.create-task {
  overflow-x: hidden;
}

.conteudo {
  padding: 20px;
  display: flex;
  justify-content: center;
}

form {
  width: 100%;
  max-width: 400px;
  display: flex;
  flex-direction: column;
  align-items: center;
}

input{
  width: 100%;
  padding: 10px;
  font-size: 1rem;
  border: 1px solid #ccc;
  margin-bottom: 55px;
    border: none;
    background-color: transparent;
    border-bottom: solid 1px #000000;
}

button {
  width: 110%;
  max-width: 500px;
  height: 65px;
  padding: 12px;
  background-color: #9f94d2;
  color: white;
  border: none;
  border-radius: 15px;
  font-size: 1rem;
  font-weight: bold;
  cursor: pointer;
  box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2);
  transition: background-color 0.3s;
}

button:hover {
  background-color: #8c83c1;
}

</style>
