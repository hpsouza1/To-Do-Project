<template>
    <div class="todo-item">
      <div>
        <h2>{{ todo.title }}</h2>
        <p>{{ todo.subtitle }}</p>
      </div>
      <div class="actions">
        <button @click="editTodo"><img src="../assets/edit-icon.png" alt="Edit" /></button>
        <button @click="deleteTodo"><img src="../assets/delete-icon.png" alt="Delete" /></button>
        <button @click="completeTodo"><img src="../assets/complete-icon.png" alt="Complete" /></button>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    props: {
      todo: Object
    },
    methods: {
      editTodo() {
        this.$emit('edit', this.todo);
      },
      deleteTodo() {
        this.$emit('delete', this.todo);
      },
      completeTodo() {
        this.$emit('complete', this.todo);
      }
    }
  };
  </script>
  
  <style scoped>
  .todo-item {
    display: flex;
    justify-content: space-between;
    background-color: rgb(255, 255, 255);
    border-radius: 10px;
    padding: 20px;
    margin: 10px 0;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  }
  .actions button {
    background: none;
    border: none;
    margin-left: 10px;
    transition: transform 0.2s ease-in-out;
  }

  .actions button:hover {
    cursor: pointer;
    transform: scale(1.2);
    transition: transform 0.2s ease-in-out;
  }

  .actions img {
    width: 20px;
  }

  </style>
  