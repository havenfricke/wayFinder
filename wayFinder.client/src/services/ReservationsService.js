import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class ReservationsService {
  async getReservationsByDestinationId(id) {
    const res = await api.get('/api/destinations/' + id + '/reservations')
    logger.log('getresrbydestid', res.data)
    AppState.reservations = res.data
  }

  async createResr(resrData) {
    resrData.destinationId = AppState.activedest.id
    const res = await api.post('/api/reservations', resrData)
    logger.log('createresr', res.data)
    AppState.reservations = AppState.reservations.push(res.data)
  }
}
export const reservationsService = new ReservationsService()