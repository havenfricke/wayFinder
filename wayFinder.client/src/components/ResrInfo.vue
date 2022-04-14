<template>
  <div class="col-2">{{ reservation.title }}</div>
  <div class="col-2">{{ reservation.type }}</div>
  <div class="col-2">{{ reservation.confirmation }}</div>
  <div class="col-2">{{ reservation.address }}</div>
  <div class="col-1">{{ new Date(reservation.date).toLocaleDateString() }}</div>
  <div class="col-1">
    <i
      data-bs-toggle="modal"
      :data-bs-target="'#myModal' + reservation.id"
      class="mdi mdi-text hoverable"
      title="Notes"
    ></i>
  </div>
  <div class="col-1">${{ reservation.cost }}</div>

  <Modal :id="'myModal' + reservation.id">
    <template #title> <h3 class="text-dark">Notes</h3> </template>
    <template #body>
      <p class="text-dark">{{ reservation.notes }}</p>
    </template>
  </Modal>
</template>

<script>
export default {
  props: {
    reservation: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  }
}
</script>

<style scoped>
.hoverable:hover {
  transform: scale(1.05);
  filter: drop-shadow(0px 15px 10px rgba(0, 0, 0, 0.3));
  transition: 222ms ease-in-out;
  cursor: pointer;
}
.hoverable:active {
  transform: scale(0.999);
  transition: 50ms ease-in-out;
}
</style>