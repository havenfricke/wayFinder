import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class DestinationsService {

  async getAllDestinations() {
    const res = await api.get('/api/destinations')
    logger.log('getalldestinations', res.data)
    AppState.destinations = res.data

  }
  async getDestinationById(id) {
    const res = await api.get('/api/destinations/' + id)
    logger.log('getdestinationbyid', res.data)
    AppState.activeDest = res.data
  }
}
export const destinationsService = new DestinationsService()