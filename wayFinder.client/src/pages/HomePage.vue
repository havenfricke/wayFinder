<template>
  <div class="container-fluid">
    <div class="row mt-3 mx-3">
      <div class="mb-3 d-flex justify-content-end">
        <button class="col-2 btn-info rounded btn">Create New Trip</button>
      </div>
      <div class="hoverable col-2" v-for="d in destinations" :key="d.id">
        <DestinationButtons :destination="d" />
      </div>
    </div>
    <div class="row mx-3">
      <div class="col-12 py-2 rounded bg-blue">
        <div
          class="
            row
            mx-3
            mb-3
            mt-2
            justify-content-around
            text-center
            border-bottom border-light
          "
        >
          <h5 class="col-2">Name</h5>
          <h5 class="col-2">Type</h5>
          <h5 class="col-2">Confirmation #</h5>
          <h5 class="col-2">Address</h5>
          <h5 class="col-1">Date</h5>
          <h5 class="col-1">Cost</h5>
          <h5 class="col-1">Notes</h5>
        </div>
        <div
          v-for="r in reservations"
          :key="r.id"
          class="
            row
            text-center
            border border-light
            rounded
            mx-2
            my-1
            bg-light
            text-dark
            justify-content-around
          "
        >
          <ResrInfo :reservation="r" />
        </div>
      </div>
    </div>

    <form @submit.prevent="createResr">
      <div class="row bg-blue p-3 rounded mx-3 mt-2 justify-content-around">
        <input
          v-model="editable.title"
          class="col-2 rounded"
          type="text"
          placeholder="Title"
        />
        <input
          v-model="editable.type"
          class="col-2 rounded"
          type="text"
          placeholder="Type"
        /><input
          v-model="editable.confirmation"
          class="col-2 rounded"
          type="text"
          placeholder="Confirmation #"
        />
        <input
          v-model="editable.address"
          class="col-2 rounded"
          type="text"
          placeholder="Address"
        /><input
          v-model="editable.date"
          class="col-1 rounded"
          type="date"
          placeholder="Date"
        />
        <input
          v-model="editable.notes"
          class="col-1 rounded"
          type="text"
          placeholder="Notes"
        />
        <input
          v-model="editable.cost"
          class="col-1 rounded"
          type="number"
          placeholder="Cost"
        />
        <div class="row justify-content-end">
          <button class="mt-2 btn col-1 rounded btn-success">Add Plan</button>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import { computed, ref, watchEffect } from "@vue/runtime-core"
import { logger } from "../utils/Logger"
import { destinationsService } from "../services/DestinationsService"
import { AppState } from "../AppState"
import { reservationsService } from "../services/ReservationsService"

export default {
  name: 'Home',
  setup() {
    const editable = ref({
      destinationId: AppState.activedest.id
    });
    watchEffect(async () => {
      try {
        await destinationsService.getAllDestinations()
      } catch (error) {
        logger.error(error)
      }
    });
    return {
      editable,
      async createResr() {
        try {
          reservationsService.createResr(editable.value)
        } catch (error) {
          logger.error(error)
        }
      },
      destinations: computed(() => AppState.destinations),
      reservations: computed(() => AppState.reservations)
    }
  }
}
</script>

<style scoped lang="scss">
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
