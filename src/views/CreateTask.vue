<!-- src/views/CreateTask.vue -->
<template>
  <div class="create-task">
    <Header title="Add Task" :showBackButton="true" />
    <div class="conteudo">
      <form @submit.prevent="addTask">
        <input type="text" id="title" v-model="title" placeholder="Title" required />
    
        <input id="description" v-model="description" placeholder="Detail" required/>
        
        <button type="submit">ADD</button>
      </form>
    </div>
  </div>
</template>

<script>
import Header from '@/components/Header.vue'

export default {
  components: {
    Header
  },
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

body {
  font-family: 'Jost', sans-serif;
  margin: 0;
  padding: 0;
  background-color: #D6D7EF;
  width: 100%;
  height: 100vh;
}
</style>
