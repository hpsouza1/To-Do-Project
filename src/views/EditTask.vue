<!-- src/views/EditTask.vue -->
<template>
  <div class="edit-task">
    <Header title="Edit Task" :showBackButton="true" />
    <div class="conteudo">
      <form @submit.prevent="editTask">
        <input
          type="text"
          id="titulo"
          v-model="titulo"
          placeholder="Title"
          required
        />
        <input
          id="descricao"
          v-model="descricao"
          placeholder="Detail"
          required
        />
        <button type="submit">SAVE</button>
      </form>
    </div>
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
import api from "../api/api";

export default {
  components: {
    Header,
  },
  data() {
    return {
      titulo: "",
      descricao: "",
    };
  },
  async created() {
    // Carrega a tarefa com base no ID passado na rota
    const taskId = this.$route.params.id;
    try {
      const response = await api.get(`/tarefa/${taskId}`);
      this.titulo = response.data.titulo;
      this.descricao = response.data.descricao;
    } catch (error) {
      console.error("Erro ao carregar a tarefa:", error);
    }
  },
  methods: {
     async editTask() {
      const updatedTask = { 
        id: this.$route.params.id, // Garantindo que o ID da tarefa seja incluído
        titulo: this.titulo, 
        descricao: this.descricao 
      };
      const taskId = this.$route.params.id;
      try {
        await api.put(`/tarefa/${taskId}`, updatedTask); // Fazendo o PUT para o ID correto
        this.$router.push("/"); // Redireciona para a página inicial após salvar as mudanças
      } catch (error) {
        console.error("Erro ao editar a tarefa:", error);
      }
    },
  },
};
</script>

<style scoped>
.edit-task {
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

input {
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
