<!-- src/views/Home.vue -->
<template>
    <div class="home">
      <Header title="TODO APP" />
      <TodoList />
      <button class="add-todo" @click="addTodo">+</button>
    </div>
</template>
  
  <script>
  import Header from '@/components/Header.vue';
  import TodoList from '@/components/TodoList.vue';
  
  export default {
    components: {
      Header,
      TodoList
    },
    methods: {
      addTodo() {
        console.log('Adding new todo...');
        this.$router.push('/create-task'); // Redireciona para a tela de criar tarefa
      }
    }
  };
  </script>
  
  <style scoped>
  .add-todo {
    position: fixed;
    bottom: 20px;
    right: 20px;
    background-color: #9f94d2;
    color: white;
    border: none;
    border-radius: 50%;
    width: 50px;
    height: 50px;
    font-size: 24px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.2);
    cursor: pointer;
    transition: background-color 0.3s ease-in-out;
  }
  

  .add-todo:hover {
    background-color: #7c69b4;
  }
  </style>
  