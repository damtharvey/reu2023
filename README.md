# TREU 2023

## Note: Due to formatting inconsistencies, these notebooks are meant to be run with Jupyter Notebook and not Google Colab. If you run them with Google Colab, the functionality will be the same, but the formatting may not. See "Installing Jupyter Notebook" for instructions on how to install and run Jupyter Notebook with Anaconda, Miniconda, or pip. Also, it may be useful for you to run these notebooks in a separate Python virtual environment. See "Virtual Environments" below for information on why virtual environments are useful, when you should/should not use them, and how to create/modify them. 

# Installing Jupyter Notebook: 

The setup for Anaconda and Miniconda will essentially be the same. Look here: https://www.educative.io/answers/anaconda-vs-miniconda to read about the differences between Anaconda and Miniconda

## Anaconda(Windows, macOS, or Linux/Unix)
1. Download Anaconda here: https://www.anaconda.com/
2. Begin Installation Process:
- Windows: Run the .exe installer
- macOS: Open the .pkg file
- Linux/Unix: Open the terminal and run: `bash Anaconda-latest-Linux-x86_64.sh`
3. Follow the prompts on the screen
4. Verfiy your installation of conda by opening the Anaconda Prompt and running `conda list`. A list of installed packages should appear if Miniconda installed correctly. Note: For macOS and Linux.Unix, you can verify in the terminal, but you will have to close and open your terminal again for changes to take effect
5. Open the Anaconda Prompt
6. To install Jupyter, use the command: `conda install jupyter`
7. To open Jupyter Notebook, use the command: `jupyter notebook`

## Miniconda (Windows, macOS, or Linux/Unix)
1. Download Miniconda: https://docs.conda.io/en/latest/miniconda.html
2. Begin Installation Process:
- Windows: Run the .exe installer
- macOS: Open the terminal and run: `bash Miniconda3-latest-MacOSX-x86_64.sh`
- Linux/Unix: Open the terminal and run: `bash Miniconda3-latest-Linux-x86_64.sh`
3. Follow the prompts on the screen
4. Verfiy your installation of conda by opening Anaconda Prompt and running `conda list`. A list of installed packages should appear if Miniconda installed correctly.
5. Open the Anaconda Prompt
6. To install Jupyter, use the command: `conda install jupyter`
7. To open Jupyter Notebook, use the command: `jupyter notebook`

## pip (Windows, macOS, or Linux/Unix) 
1. In order to install and use pip, you will need make sure that you have a working version of Python installed on your computer. See "Installing Python" below for details on how to install Python. You can verify an installation of Python using the command `python --version` (`python3 --version` on macOS).
2. Typically, pip will come with Python. You can check using the command: `pip --version`. If it is not already installed, run the following commands to install it on your machine: 

    `curl https://bootstrap.pypa.io/get-pip.py -o get-pip.py`

    `python get-pip.py` (Use `python3 get-pip.py` for macOS)

3. Verify the pip installation by checking the version. 
4. To install Jupyter Notebook, use the command: `pip install notebook`
5. To run Jupyter Notebook, use the ccommand: `jupyter notebook`

# Installing Python

## Windows and macOS
1. To install Python on Windows and macOS, use the following link: https://www.python.org/downloads/. (For Windows, make sure the "Add Python to PATH" box is checked when running the installer)
2. Once the installation process is finished, you can use the command `python --version` (`python3 --version` on macOS) to verify Python was installed correctly.
- Note: For macOS you can also use the HomeBrew package manager to install Python. For more information, use the following link: https://www.geeksforgeeks.org/how-to-download-and-install-python-latest-version-on-macos-mac-os-x/

## Linux/Unix
1. To install Python on Linux/Unix machines, open the terminal and use the command: `sudo apt-get install python3` Note: If you would like a specific version of Python installed, you can use the command: `sudo apt-get install python3.$` where $ should replaced by the version that you would like. 
2. Press Y and Enter when prompted to finish the installation
3. Verify that Python was installed correctly with: `python --version` 

# Virtual Environments with Python

Virtual environments in Python allow you to group together all of the necessary packages for a sepcific project. They are extremely useful if you you have multiple projects where each project requires a different version of Python or a different version of some other package. They also isolate each project, ensuring they do not intefere with one another.  This section contains information on how to create, modify, and use virtual environments with Anaconda, Miniconda, and pip. For more information on virtual environments, read: https://www.freecodecamp.org/news/how-to-setup-virtual-environments-in-python/ 

## Anaconda and Miniconda
 For more information about conda environments, how to create and modify them, and what they can be useful for follow these links: 
 - https://conda.io/projects/conda/en/latest/user-guide/tasks/manage-environments.html
 - https://www.freecodecamp.org/news/why-you-need-python-environments-and-how-to-manage-them-with-conda-85f155f4353c/

 ## pip
 For more information on pip, how to create virtual environments, and how to manage packages within virtual environments use the following link: 

- https://packaging.python.org/en/latest/guides/installing-using-pip-and-virtual-environments/#:~:text=To%20create%20a%20virtual%20environment,virtualenv%20in%20the%20below%20commands.&text=The%20second%20argument%20is%20the,project%20and%20call%20it%20env%20.

For an example of how how to create a virtual environment with pip to run Jupyter Notebook use the following link: 

- https://medium.com/analytics-vidhya/how-to-install-jupyter-notebook-using-pip-e597b5038bb1