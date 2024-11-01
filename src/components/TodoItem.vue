<template>
  <div class="todo-item">
    <div>
      <h2>{{ todo.titulo }}</h2>
      <p>{{ todo.descricao }}</p>
    </div>
    <div class="actions">
      <button @click="editTodo">
        <img src="../assets/edit-icon.png" alt="Edit" />
      </button>
      <button @click="deleteTodo">
        <img src="../assets/delete-icon.png" alt="Delete" />
      </button>
      <button @click="completeTodo">
        <img src="../assets/complete-icon.png" alt="Complete" />
      </button>
    </div>
  </div>
</template>

<script>
import api from "../api/api"; // Certifique-se de que o caminho esteja correto

export default {
  props: {
    todo: Object,
  },
  methods: {
    editTodo() {
    this.$router.push({ path: `/edit-task/${this.todo.id}` });
    },
    async deleteTodo() {
      try {
        // Adiciona a rota correta ao deletar
        await api.delete(`/tarefa/${this.todo.id}`);
        // Emite um evento para que o componente pai saiba que a tarefa foi deletada
        this.$emit("delete", this.todo.id);
        window.location.reload(); // Recarrega a página para garantir que tudo está atualizado

        console.log(`Tentando deletar a tarefa com ID: ${this.todo.id}`);

      } catch (error) {
        console.error("Erro ao deletar a tarefa:", error);

      }
    },

    completeTodo() {
      this.$emit("complete", this.todo);
      
    },
  },
};
</script>

<style scoped>
.todo-item {
  display: flex;
  justify-content: space-between;
  background-color: rgb(255, 255, 255);
  border-radius: 15px;
  padding: 20px;
  margin: 10px;
  margin-bottom: 25px;
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
  width: 15px;
  margin-top: 100%;
}

h2 {
  color: #9395d3;
  font-size: 13px;
  font-weight: bold;
}

p {
  font-size: 10px;
}
</style>
