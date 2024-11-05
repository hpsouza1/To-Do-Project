<template>
  <div class="todo-item">
    <div>
      <h2>{{ todo.titulo }}</h2>
      <p>{{ todo.descricao }}</p>
    </div>
    <!-- Mostra as ações apenas se não estiver em CompletedTasks -->
    <div class="actions" v-if="!isCompletedView">
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
    isCompletedView: {
      type: Boolean,
      default: false
    }
  },
  methods: {
    editTodo() {
      this.$router.push({ path: `/edit-task/${this.todo.id}` });
    },
    async deleteTodo() {
      try {
        await api.delete(`/tarefa/${this.todo.id}`);
        this.$emit("delete", this.todo.id);
        window.location.reload();
      } catch (error) {
        console.error("Erro ao deletar a tarefa:", error);
      }
    },
    async completeTodo() {
      try {
        await api.put(`/tarefa/complete/${this.todo.id}`);
        this.$emit("complete", this.todo);
        
        this.$router.push({ path: `/completed-tasks` }).then(() => {
          window.location.reload();
        });
      } catch (error) {
        console.error("Erro ao completar a tarefa:", error);
      }
    }
  }
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
