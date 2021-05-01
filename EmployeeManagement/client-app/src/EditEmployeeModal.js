import { useEffect, useState } from 'react';
import {Table, Button,ButtonToolbar, Modal, Row, Col, Form, Card} from 'react-bootstrap';
import './EditEmployeeModal.css';

const EditEmployeeModal = ({modalShow, closeModal, employee}) => {
  const [employeeDetailed, setEmployeeDetailed] = useState({});

  useEffect(() => {
    getEmployeeDetails();
  }, [employee])

  const getEmployeeDetails = async () => {
    let response = await fetch(`api/employees/${employee.employeeId}`, {
      method: 'GET',
    });

    setEmployeeDetailed(await response.json());
  }

  const editHandleSubmit = async (event) => {
    event.preventDefault();
    
    await fetch(`api/employees/${event.target.employeeId.value}`,{
      method:'PUT',
      headers:{
        'Accept':'application/json',
        'Content-Type':'application/json'
      },
      body:JSON.stringify({
        name:event.target.name.value,
        position:event.target.position.value
      })
    });

    closeModal();
  };

  return (
    <Modal
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
      show={modalShow}
    >
        <Modal.Header>
          <Modal.Title>Edit Employee</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Row>
            <Col sm={6}>
              <Form onSubmit={editHandleSubmit}>
                <Form.Group controlId="employeeId">
                    <Form.Label>ID</Form.Label>
                    <Form.Control type="text" name="employeeId" required disabled
                    defaultValue={employee?.employeeId}
                    placeholder="ID"/>
                </Form.Group>
                        
                <Form.Group controlId="name">
                  <Form.Label>Name</Form.Label>
                  <Form.Control type="text" name="name" required 
                  defaultValue={employee?.name}
                  placeholder="Name"/>
                </Form.Group>

                <Form.Group controlId="position">
                  <Form.Label>Position</Form.Label>
                  <Form.Control type="text" name="position" required
                  defaultValue={employee?.position} 
                  placeholder="Position"/>
                </Form.Group>

                <Form.Group>
                  <Button variant="primary" type="submit">
                    Update Employee
                  </Button>
                </Form.Group>
              </Form>
            </Col>
            <Col sm={6} className='d-flex flex-column'>
              <p>History</p>
              <div className='flex-grow-1'>
                <div className='history-container'>
                    {employeeDetailed.editHistories?.map(history => {
                      return (
                        <Card>
                          <Card.Body className='history-card-body'>
                            <p><b>{history.timestamp}</b></p>
                            <p>{history.name}</p>
                            <p>{history.position}</p>
                          </Card.Body>
                        </Card>
                      );
                    })}
                </div>
              </div>
          </Col>
        </Row>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="danger" onClick={() => closeModal()}>Close</Button>
      </Modal.Footer>
    </Modal>
  );
};

export default EditEmployeeModal;